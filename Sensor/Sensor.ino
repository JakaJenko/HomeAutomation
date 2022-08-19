#include <ESP8266WiFi.h>
#include <espnow.h>

#define CODE_VERSION 0
#define MAX_RETRIES 2

enum key {
  VERSION,
  TEMPERATURE,
  HUMIDITY 
};

typedef struct message {
  key Key[];
  int Value[];
} message;

uint8_t gateway[] = {0x48, 0x3F, 0xDA, 0x00, 0xFC, 0xCF};

int retryCounter;
message Data;

void OnDataSent(uint8_t *mac_addr, uint8_t sendStatus) {
  if (sendStatus == 0){
    retryCounter = 0;
  }
  else{
    retryCounter++;
    if(retryCounter < MAX_RETRIES){
      SendData();
    }
    else
    {
      retryCounter = 0;  
    }
  }
}

void OnDataRecv(uint8_t * mac, uint8_t *incomingData, uint8_t len) {
  message dataFromGateway;
  memcpy(&dataFromGateway, incomingData, sizeof(dataFromGateway));
}
 
void setup() {
  Serial.begin(115200);
  
  WiFi.mode(WIFI_STA);

  // Init ESP-NOW
  if (esp_now_init() != 0) {
    return;
  }

  // get the status of Trasnmitted packet
  esp_now_set_self_role(ESP_NOW_ROLE_CONTROLLER);
  esp_now_register_send_cb(OnDataSent);
  esp_now_register_recv_cb(OnDataRecv);
  
  // Register peer
  esp_now_add_peer(gateway, ESP_NOW_ROLE_CONTROLLER, 1, NULL, 0);

  SetData();
  SendData();

  //60 sec seep sleep
  ESP.deepSleep(60e6);
}

void loop() {}

void SetData(){
  Data.Key[0] = VERSION;
  Data.Key[1] = TEMPERATURE;
  Data.Key[2] = HUMIDITY;

  Data.Value[0] = CODE_VERSION;
  Data.Value[1] = 42;
  Data.Value[2] = random(1, 100);
}

void SendData(){
  esp_now_send(gateway, (uint8_t *) &Data, sizeof(Data));
}
