package com.chrynan.android_guitar_tuner.Bluetooth;

import android.bluetooth.BluetoothSocket;
import android.util.Log;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;

public class BluetoothConnection extends Thread {

    private static final String TAG = "Bluetooth_MagicCall";

    private static BluetoothSocket bluetoothSocket;
    private static InputStream streamReader;

    private byte[] buffer;
    private int bytesAvailable;

    private static List<IBluetoothReceiver> listeners;


    public BluetoothConnection(BluetoothSocket bluetoothSocket) {
        this.bluetoothSocket = bluetoothSocket;
        tryGetStream();

        buffer = new byte[1024];
        listeners = new ArrayList<>();
    }

    private void tryGetStream() {
        try {
            getStream();
        } catch (IOException e) {
            Log.e(TAG, "Error to get Bluetooth Stream", e);
        }
    }

    private void getStream() throws IOException {
        streamReader = bluetoothSocket.getInputStream();
    }

    @Override
    public void run() {
        super.run();

        while(true) {
            action();
        }
    }

    private void action() {

        try {
            readIfAvailable();
        } catch (IOException e) {
            Log.e(TAG, "Error reading Message", e);
        }

    }

    private void readIfAvailable() throws IOException {
        read();
        if (bytesAvailable > 0) notifyReceivers();
    }

    private void read() throws IOException {
        bytesAvailable = streamReader.read(buffer);
    }

    private void notifyReceivers() {
        String messageReceived = new String(buffer, 0, bytesAvailable);

        for (int i = 0; i < listeners.size(); i++)
            listeners.get(i).messageReceived(messageReceived);
    }

    public static void add(IBluetoothReceiver bluetoothReceiver) {
        listeners.add(bluetoothReceiver);
    }

    public void closeConnection() {
        if (bluetoothSocket.isConnected()) close();
    }

    private void close() {
        try {
            bluetoothSocket.close();
        } catch (IOException e) {
            Log.e(TAG, "Error closing socket", e);
        }
    }

}
