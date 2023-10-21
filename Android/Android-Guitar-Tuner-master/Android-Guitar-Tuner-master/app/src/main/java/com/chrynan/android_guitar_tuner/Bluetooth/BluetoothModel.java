package com.chrynan.android_guitar_tuner.Bluetooth;

public class BluetoothModel {

    private String name;
    private String macAddress;

    public BluetoothModel() {
    }

    public BluetoothModel(String name, String macAddress) {
        this.name = name;
        this.macAddress = macAddress;
    }


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getMacAddress() {
        return macAddress;
    }

    public void setMacAddress(String macAddress) {
        this.macAddress = macAddress;
    }

    @Override
    public String toString() {
        return name;
    }

}
