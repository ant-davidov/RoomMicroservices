docker build -f ./Room\RoomMicroservices\Dockerfile -t room:latest . <br />
docker build -f ./Building\BuildingMicroservices\Dockerfile -t building:latest .

из корневого раздела. 

затем docker compose up <br />
api room http://localhost:8181/swagger/index.html <br />
api building  http://localhost:8182/swagger/index.html <br />
angular  http://localhost
