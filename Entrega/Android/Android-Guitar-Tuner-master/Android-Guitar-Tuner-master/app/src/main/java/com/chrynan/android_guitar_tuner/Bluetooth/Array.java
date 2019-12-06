package com.chrynan.android_guitar_tuner.Bluetooth;

import java.util.List;

public class Array {

    public static String[] listToArray(List<String> list) {
        String[] array = new String[list.size()];
        list.toArray(array);
        return array;
    }

}
