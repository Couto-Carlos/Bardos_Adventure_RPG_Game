package com.chrynan.android_guitar_tuner.Bluetooth;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

public class BluetoothController implements IBluetoothReceiver {

    private BluetoothAdapter bluetoothAdapter;


    public BluetoothController() {
        bluetoothAdapter  = BluetoothAdapter.getDefaultAdapter();
    }

    public boolean deviceSupportBluetooth() {
        return bluetoothAdapter != null;
    }

    public boolean isBluetoothEnabled() {
        return bluetoothAdapter.isEnabled();
    }

    public List<BluetoothDevice> getPairedDevices() {
        Set<BluetoothDevice> pairedDevices = bluetoothAdapter.getBondedDevices();

        List<BluetoothDevice> devices = new ArrayList<>();
        devices.addAll(pairedDevices);

        return devices;
    }

    @Override
    public void messageReceived(String messageReceived) {

    }



}
