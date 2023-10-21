package com.chrynan.android_guitar_tuner.Bluetooth;

import android.bluetooth.BluetoothSocket;


public interface IBluetoothConnection {
    void startConnection(BluetoothSocket socket);
    void write(byte[] bytes);
    void stopConnection();
}
