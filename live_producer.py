import cv2
from kafka import KafkaProducer

producer = KafkaProducer(bootstrap_servers='localhost:9092')

cap = cv2.VideoCapture(0)
while(True):
    ret, frame = cap.read()
    cv2.imshow('live_camera', frame)

    retval, img  = cv2.imencode('.png', frame)

    producer.send('live-no99', img.tobytes())

    if cv2.waitKey(1) & 0xFF == ord('q'): break

cap.release()
cv2.destroyAllWindows()
