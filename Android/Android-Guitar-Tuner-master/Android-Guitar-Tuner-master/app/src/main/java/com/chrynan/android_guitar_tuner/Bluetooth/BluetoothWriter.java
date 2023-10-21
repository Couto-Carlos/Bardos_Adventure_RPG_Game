package com.chrynan.android_guitar_tuner.Bluetooth;

import android.bluetooth.BluetoothSocket;
import android.util.Log;

import java.io.IOException;
import java.io.OutputStream;

public class BluetoothWriter implements IBluetoothConnection {

    private static final String TAG = "Bluetooth_Magicall";

    private BluetoothSocket bluetoothSocket;
    private OutputStream streamWriter;


    public void write(String messageToWrite) {
        write(messageToWrite.concat("\n").getBytes());
    }

    public void write(int messageToWrite) {
        String message = String.valueOf(messageToWrite);
        write(message.concat("\n").getBytes());
    }


    @Override
    public void startConnection(BluetoothSocket socket) {
        bluetoothSocket = socket;
        getOutputStream();
    }

    @Override
    public void write(byte[] bytes) {
        try {
            streamWriter.write(bytes);
        } catch (IOException e) {
            Log.e(TAG, "Error writing", e);
        }
    }

    @Override
    public void stopConnection() {
        if (bluetoothSocket.isConnected()) close();
    }

    private void getOutputStream() {
        try {
            streamWriter = bluetoothSocket.getOutputStream();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void close() {
        try {
            bluetoothSocket.close();
        } catch (IOException e) {
            Log.e(TAG, "Error closing socket", e);
        }
    }

}