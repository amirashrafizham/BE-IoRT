# :space_invader: .NET Robotics IoT API

[![Build status](https://dev.azure.com/amirashrafizham7/IoT%20RaspberryPI/_apis/build/status/Backend%20-%20IoRT%20Raspberry%20Pi)](https://dev.azure.com/amirashrafizham7/IoT%20RaspberryPI/_build/latest?definitionId=4)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=amirashrafizham_BE-IoRT&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=amirashrafizham_BE-IoRT)

![Azure DevOps builds](https://img.shields.io/azure-devops/build/amirashrafizham7/3cd2d062-7beb-450b-835a-acb34a7cc906/4)
![Azure DevOps releases](https://img.shields.io/azure-devops/release/amirashrafizham7/3cd2d062-7beb-450b-835a-acb34a7cc906/4/4)

## :thought_balloon: About
This is a .NET Backend API project and has the following features :
- Remotely maneuvre a robot through a web browser [Feb 2022 Release]
- Retrieve and monitor IoT sensor data displayed on the dashboard [Feb 2022 Release]
- Camera video streaming in real-time [Apr 2022 Release]

![MicrosoftTeams-image (4)](https://user-images.githubusercontent.com/59201954/157059323-35ff4bd5-6491-4976-825f-8644b4d21c55.png)

### Features to be added in future release  

1. **Robot Control Panel module**
   - SignalR and BackgroundService to enable real-time IoT sensor monitoring (Temperature, Humidity, Pressure)
   - Ultrasonic sensor integration to detect collision
   - Robot speed sensor integration to monitor the rover's speed
   - Battery status integration to monitor the leftover battery on the RaspberryPi
   - Camera stream integration 

2. **Weather Station module**
   - Line chart to monitor sensor trends for T-10 seconds 
   - MongoDB to store IoT sensor data

3. **DevSecOps**
   - Perform Static Code Analysis with SonarCloud :white_check_mark:
   - Perform unit testing with XUnit
   - Integrate unit testing into CI Pipeline and generate code coverage 

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

## :film_strip: Demo

<h6>Controlling the rover from a mobile device</h6>
   
<img src="https://user-images.githubusercontent.com/59201954/158006331-2770bfc3-a9bc-4d32-8133-aac5ad348dfb.GIF" height=100% width=100%>

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
3. Download the docker image : `amirashrafizham/be-iort`
4. Run the following docker command : `sudo docker run --privileged -p 5000:80  --name be-iort --detach --restart unless-stopped amirashrafizham/be-iort`

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)


## :computer: Code Structure

![CodeStructure](https://user-images.githubusercontent.com/59201954/157164860-2238caa9-8f78-46bb-87c9-271151f7e003.png)

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
Due to the limitation of the 32-bit Pi-Top OS as of Apr 2022, the project will be built using .NET 6 on local machine and configured to .NET 5 on the server. These are the steps to build and release the code to the RaspberryPi Server

1. From local machine, push the latest code update to Github
2. Azure Pipelines will automatically trigger the CI pipeline
3. The CI pipeline will download .csproj and Dockerfile.stg hosted on Azure DevOps secure file. These files are configured for .NET5
4. Overwrite .csproj and store Dockerfile.dev from $(Agent.TempDirectory) to $(Build.Repository.LocalPath)
5. Build and containerize the code using Dockerfile.stg. The Dockerfile has the following main commands
   - `docker stop` old image
   - `docker remove` old image
   - `docker run` new image with privileged access, detached mode, restart-unless-stop and point to port 5000
6. Push to Dockerhub for backup
7. Azure Pipelines will then automatically trigger the CD pipeline with the following main commands
   - `docker stop` old image
   - `docker remove` old image
   - `docker run` new image with privileged access, detached mode, restart-unless-stop and point to port 5000
   - `docker remove` images on the server with <None> label `<none>`

![Screenshot 2022-03-07 232948](https://user-images.githubusercontent.com/59201954/157065033-29a79063-0592-4e24-925d-caf14222b8eb.png)

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

## :artificial_satellite: Connectivity

To access the Swagger API, simply point the IP address of the RaspberryPi with port 5000 and the extension /swagger/index.html

![SwaggerScreenshot](https://user-images.githubusercontent.com/59201954/157164825-41b3da22-946e-4c94-9de7-0b5e4365a102.png)

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)
