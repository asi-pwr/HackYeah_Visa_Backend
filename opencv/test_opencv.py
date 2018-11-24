import sys
import recognize as rec
import opencv as cv

#import OpenCV for test puprose
import cv2

subjects = ["", "Kuba", "Tomek", "Łukasz", "asia"]

if int(sys.argv[1]) == 0:
    recognizer = cv.train_run(True)
else:
    recognizer = cv.train_run(False)

test_img1 = cv.cv2.imread(sys.argv[2])
rec.recognize_by_img(test_img1, recognizer, subjects)
