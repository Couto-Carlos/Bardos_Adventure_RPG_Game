package com.chrynan.android_guitar_tuner.ui.activity;

public class SetFrequency {
    public static String nota = "";

    public SetFrequency(){

    }
    public static String Frequency(double f){
            //D - 588 // F - 700 // A - 875 // B - 990 // D2 - 1024
        if (f > 560 && f < 600) {
            return  nota = "D";
        }else if(f > 680 && f < 720){
            return  nota = "F";
        }else if(f > 970 && f < 1020){
            return  nota = "B";
        }else if(f > 855 && f < 895){
            return nota = "A";
        }else if(f > 1100 && f < 1200){
            return nota = "G";
        }else {
            return nota = "";
        }
    }

}
