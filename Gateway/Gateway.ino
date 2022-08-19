#include <ESP8266WiFi.h>
#include <espnow.h>

enum key {
  VERSION,
  TEMPERATURE,
  HUMIDITY 
};


typedef struct message {
  key Key[];
  int Value[];
} message;


uint8_t sensor1[] = {0x48, 0x3F, 0xDA, 0x00, 0x6C, 0x8C};


void OnDataSent(uint8_t *mac_addr, uint8_t sendStatus) {
  if (sendStatus == 0){
    Log("Sent success");
  }
  else{
    Log("Sent fail");
  }
}

void OnDataRecv(uint8_t * mac, uint8_t *incomingData, uint8_t len) {
  message Data;
  memcpy(&Data, incomingData, sizeof(Data));

  for (byte i = 0; i < sizeof(Data.Key) / sizeof(Data.Key[0]); i++) {
    LogData(Data.Key[i], Data.Value[i]);
  }
  

  // TODO
  /*
  uint8_t sendToAddress;
  memcpy(&sendToAddress, mac, sizeof(sendToAddress));

  messageToSensors DataToSensors;
  // TODO - get data from API
  
  esp_now_send(sendToAddress, (uint8_t *) &DataToSensors, sizeof(DataToSensors));
  // TODO - call API to log sent data
  */
}
 
void setup() {
  Serial.begin(115200);
  
  WiFi.mode(WIFI_STA);

  // Init ESP-NOW
  if (esp_now_init() != 0) {
    Log("Error initializing ESP-NOW");
    return;
  }

  // get the status of Trasnmitted packet
  esp_now_set_self_role(ESP_NOW_ROLE_CONTROLLER);
  esp_now_register_send_cb(OnDataSent);
  esp_now_register_recv_cb(OnDataRecv);
  
  // Register peer
  esp_now_add_peer(sensor1, ESP_NOW_ROLE_CONTROLLER, 1, NULL, 0);
  Log("Setup completed");
}

void loop() {}

void Log(String data){
  Serial.print("Log: ");
  Serial.println(data);
}

void LogData(key key, int value){
  Serial.println(key);
  Serial.print(": ");
  Serial.println(value);
}
