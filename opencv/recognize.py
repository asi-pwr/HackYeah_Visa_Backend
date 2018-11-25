import sys
import opencv.opencv as cv

def recognize_by_img(img, face_recognizer, subjects):
    print("Predicting image...")
    predicted_img, img_class = cv.predict(img, face_recognizer, subjects)
    print("Prediction complete")
    print(str(img_class) + " - " + subjects[img_class])
    return img_class
