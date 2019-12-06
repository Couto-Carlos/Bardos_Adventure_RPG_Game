package com.chrynan.android_guitar_tuner.ui.activity;

import android.Manifest;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.Context;
import android.content.Intent;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.chrynan.android_guitar_tuner.Bluetooth.BluetoothController;
import com.chrynan.android_guitar_tuner.Bluetooth.BluetoothManager;
import com.chrynan.android_guitar_tuner.Bluetooth.PermissionsController;
import com.chrynan.android_guitar_tuner.R;
import com.chrynan.android_guitar_tuner.tuner.GuitarTuner;

import java.util.ArrayList;
import java.util.Set;

public class BluetoothActivity extends AppCompatActivity {

    ListView lista;
    ArrayList list = new ArrayList();
    private String[] permissions = {
            Manifest.permission.RECORD_AUDIO,
    };
    private Set<BluetoothDevice> pairedDevices;
    private BluetoothAdapter Bluetooth;
    private final int PERMISSIONS_REQUEST_CODE = 1;
    BluetoothController bluetoothController;
    public static Intent newIntent(final Context context) {
        return new Intent(context, BluetoothActivity.class);
    }
    ////
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bluetooth);
        checkPermissions();
        Bluetooth = BluetoothAdapter.getDefaultAdapter();
        inicializeBluetooth();

        lista  = findViewById(R.id.list);
        lista.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
                BluetoothManager.A(arg2);
                startActivity(GuitarTunerActivity.newIntent(BluetoothActivity.this));
            }
        });
    }

    private void inicializeBluetooth() {
        bluetoothController = new BluetoothController();

        if (!bluetoothController.deviceSupportBluetooth()) {
            Toast.makeText(this, "Nao suporta", Toast.LENGTH_LONG).show();
            return;
        }

        if (!bluetoothController.isBluetoothEnabled()) {
            startIntentToEnableBluetooth();
        }
    }
    private void startIntentToEnableBluetooth() {
        Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
        startActivityForResult(enableBtIntent, 1);
    }
    private void checkPermissions() {
        PermissionsController permissionsController = new PermissionsController(
                this,
                permissions,
                PERMISSIONS_REQUEST_CODE
        );
        permissionsController.checkPermissions();
    }
    public void list(View v) {
            pairedDevices = Bluetooth.getBondedDevices();
            ArrayList list = new ArrayList();
            for (BluetoothDevice bt : pairedDevices) list.add(bt.getName());
            Toast.makeText(getApplicationContext(), "Mostrando aparelhos pairados", Toast.LENGTH_SHORT).show();
            final ArrayAdapter adapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, list);
            BluetoothManager.getBluetoothManager(BluetoothActivity.this).choose_paired_devices(BluetoothActivity.this);
            lista.setAdapter(adapter);
    }

    public void on(View v){
        if (!Bluetooth.isEnabled()) {
            Intent turnOn = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(turnOn, 0);
            Toast.makeText(getApplicationContext(), "Ligado",Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(getApplicationContext(), "Ja está ligado", Toast.LENGTH_LONG).show();
        }

    }

    public void off(View v){
        Bluetooth.disable();
        Toast.makeText(getApplicationContext(), "Desligado" ,Toast.LENGTH_LONG).show();

    }


    public  void visible(View v){
        Intent getVisible = new Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
        startActivityForResult(getVisible, 0);

    }
}
