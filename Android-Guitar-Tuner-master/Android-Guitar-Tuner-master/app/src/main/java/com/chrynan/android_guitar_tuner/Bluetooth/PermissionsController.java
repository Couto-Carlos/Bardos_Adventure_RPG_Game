package com.chrynan.android_guitar_tuner.Bluetooth;


import android.app.Activity;
import android.content.pm.PackageManager;
import android.os.Build;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;

import java.util.ArrayList;
import java.util.List;

public class PermissionsController {

    private Activity activity;
    private String[] permissions;
    private final int requestCodeId;

    public PermissionsController(Activity activity, String[] permissions, int requestCodeId) {
        this.activity = activity;
        this.permissions = permissions;
        this.requestCodeId = requestCodeId;
    }


    public void checkPermissions() {
        if (!(Build.VERSION.SDK_INT >= Build.VERSION_CODES.M)) return;
        List<String> permissionsNeeded = getNoGrantedPermissions();
        if (permissionsNeeded.isEmpty()) return;

        String[] permissionsToRequest = Array.listToArray(permissionsNeeded);
        requestPermission(permissionsToRequest);
    }

    private List<String> getNoGrantedPermissions() {
        List<String> permissionsNeeded = new ArrayList<>();

        for (String permission : permissions) {
            if (!hasGrantedPermission(permission)) {
                permissionsNeeded.add(permission);
            }
        }

        return permissionsNeeded;
    }

    private boolean hasGrantedPermission(String permission) {
        int permissionCheck = ContextCompat.checkSelfPermission(activity, permission);
        return permissionCheck == PackageManager.PERMISSION_GRANTED;
    }

    private void requestPermission(String[] permissionsToRequest) {
        //ActivityCompat.shouldShowRequestPermissionRationale
        ActivityCompat.requestPermissions(activity, permissionsToRequest, requestCodeId);
    }

}
