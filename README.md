# :space_invader: .NET Robotics IoT API

[![Build status](https://dev.azure.com/amirashrafizham7/IoT%20RaspberryPI/_apis/build/status/Backend%20-%20IoRT%20Raspberry%20Pi)](https://dev.azure.com/amirashrafizham7/IoT%20RaspberryPI/_build/latest?definitionId=4)

![Azure DevOps builds](https://img.shields.io/azure-devops/build/amirashrafizham7/3cd2d062-7beb-450b-835a-acb34a7cc906/4)
![Azure DevOps releases](https://img.shields.io/azure-devops/release/amirashrafizham7/3cd2d062-7beb-450b-835a-acb34a7cc906/4/4)

## :thought_balloon: About
This is a .NET Backend API project and has the following features :
- The user is able to remotely manoeuvre a robot through a web browser
- The user is able to retrieve and monitor IoT sensor data displayed on the dashboard

![MicrosoftTeams-image (4)](https://user-images.githubusercontent.com/59201954/157059323-35ff4bd5-6491-4976-825f-8644b4d21c55.png)

### Features to be added in future release  

1. **Robot Control Panel module**
   a. SignalR and BackgroundService to enable real-time IoT sensor monitoring (Temperature, Humidity, Pressure)
   b. Ultrasonic sensor integration to detect collision 
   c. Robot speed sensor integration to monitor the rover's speed
   d. Battery status integration to monitor the leftover battery on the RaspberryPi

2. **Weather Station module**
   a. Line chart to monitor sensor trends for T-10 seconds
   b. MongoDB to store IoT sensor data 

3. **DevSecOps**
   a. Perform Static Code Analysis with SonarCloud
   b. Perform unit testing with XUnit

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

## :hammer_and_wrench: Tech Stack

| Technology          | Remarks                                                                                          |
|---------------------|--------------------------------------------------------------------------------------------------|
| .NET Web API        |  Backend API logic  built with .NET 5                                                            |
| RaspberryPi         |  Server to host the Backend API logic and to host the Azure DevOps agent for CICD                |
| Docker              |  Containerization platform to host the Backend API logic                                         |
| Azure DevOps        |  Continuous Integration/Continuous Deployment platform                                           |
| Pi-Top Robotics Kit |  Hardware to maneuver the robot by Pi-Top - Pi-Top OS is used to integrate with the peripherals  |
| SenseHat            |  Hardware to capture IoT sensor data             


![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

## :fireworks: Installation
### Hardware 

The following hardware is required prior to installing the software
1. RaspberryPi 4B+ 
2. Pi-Top Robotics Kit
3. SenseHat

### Software

1. Install Docker engine on the RaspberryPi
2. Install .NET 5 / .NET 6 on the RaspberryPi
3. Download the docker image : amirashrafizham/be-iort
4. Run the following docker command : sudo docker run --privileged -p 5000:80  --name be-iort --detach --restart unless-stopped amirashrafizham/be-iort

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)


## Code Structure

![WebAPI](https://user-images.githubusercontent.com/59201954/157067077-fbab5e78-eb9e-436b-bc4c-622c4ec545ae.png)

### Pattern

The project follows the Repository pattern, where C# classes called Services will be instantiated into the Controller using Dependency Injection

### Modules

1. RobotWheel - This is the service to manoeuvre the robot  
2. PiSenseHat - This is the service to retrieve the Iot sensor data

### Libraries
 
1. IoT.Device.Bindings
2. Pi-Top
3. Pi-Top.MakerArchitecture
4. System.Device.Gpio


![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

## :rocket:	CICD
These are the steps to build and release the code to the RaspberryPi Server
1. From local machine, push the latest code update to Github
2. Azure Pipelines will automatically trigger the CI pipeline to build and containerize the code with Dockerfile. The Dockerfile has the following main commands
    a. Dotnet restore
    b. Dotnet build
    c. Dotnet publish
    d. Generate runtime image
3. Push to Dockerhub for backup
4. Azure Pipelines will then automatically trigger the CD pipeline with the following main commands
    a. Docker stop old image
    b. Docker remove old image
    c. Docker run new image with privileged access, detached mode, restart-unless-stop and point to port 5000
    d. Remove Docker images on the server with <None> label

![Screenshot 2022-03-07 232948](https://user-images.githubusercontent.com/59201954/157065033-29a79063-0592-4e24-925d-caf14222b8eb.png)

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

## :artificial_satellite: Connectivity

1. Open Swagger documentation at port 5000

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)
