package com.chrynan.android_guitar_tuner.ui.activity;

import com.chrynan.android_guitar_tuner.Bluetooth.BluetoothManager;
import com.chrynan.android_guitar_tuner.tuner.GuitarTuner;

public class ThreadToFrequency extends  Thread{

    @Override
    public void run(){
SetFrequency set = new SetFrequency();
        while(true){


            try {
                MandarFrequencia();
                //System.out.println(GuitarTuner.note.getName());
                sleep(10);
            }catch(Exception e){

            }
        }
    }


    public void MandarFrequencia(){

       // System.out.println("Mandando frequência");
        BluetoothManager.write( SetFrequency.Frequency(GuitarTuner.frequency) + "\n",GuitarTunerActivity.getInstance());

            }



}
