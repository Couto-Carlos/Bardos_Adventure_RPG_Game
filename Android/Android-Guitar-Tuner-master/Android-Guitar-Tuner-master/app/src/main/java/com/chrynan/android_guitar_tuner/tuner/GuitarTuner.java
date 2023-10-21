package com.chrynan.android_guitar_tuner.tuner;

import android.os.Debug;
import android.util.Log;

import com.chrynan.android_guitar_tuner.Bluetooth.BluetoothManager;
import com.chrynan.android_guitar_tuner.tuner.detection.PitchDetector;
import com.chrynan.android_guitar_tuner.tuner.note.MutableNote;
import com.chrynan.android_guitar_tuner.tuner.note.Note;
import com.chrynan.android_guitar_tuner.tuner.note.NoteFinder;
import com.chrynan.android_guitar_tuner.tuner.recorder.AudioRecorder;
import com.chrynan.android_guitar_tuner.ui.activity.GuitarTunerActivity;
import com.chrynan.android_guitar_tuner.ui.activity.SetFrequency;

import io.reactivex.Observable;

/**
 * An implementation of the {@link Tuner} interface.
 */
public class GuitarTuner implements Tuner {

    public static final MutableNote note = new MutableNote();

    private final Observable<Note> observable;
    public SetFrequency set = new SetFrequency();
    public static double frequency;

    public GuitarTuner(final AudioRecorder audioRecorder, final PitchDetector detector, final NoteFinder finder) {
        //new Exception("ALOO").printStackTrace();
        // Initialize the Observable to be for listening to notes
        observable = Observable.create(emitter -> {
            try {
                audioRecorder.startRecording();

                while (!emitter.isDisposed()) {
                    frequency = detector.detect(audioRecorder.readNext());
                    finder.setFrequency(frequency);
                    // Since the note object has mutable fields and we return the same instance,
                    // lock the object while updating its data
                    synchronized (note) {
                        note.setFrequency(frequency);
                        System.out.println(frequency);
                       // BluetoothManager.write(GuitarTuner.frequency, GuitarTunerActivity.class);
                       // GuitarTunerActivity.SendFreq();
                        //System.out.println("Mandou");
                        note.setName(finder.getNoteName());
                        note.setPercentOffset(finder.getPercentageDifference());

                    }
                    emitter.onNext(note);
                }

                audioRecorder.stopRecording();

                emitter.onComplete();
            } catch (Exception exception) {
                emitter.tryOnError(exception);
            }
        });
    }



    @Override
    public Observable<Note> startListening() {
        return observable.share();
    }
}
