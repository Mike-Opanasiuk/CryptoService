This application is a simple example of Crypto service. It allows for users to get orders info, register, login, etc.

Class diagram is available in [class diagram.drawio] file and can be opened at online service draw.io.

To start working with the project:

Clone project to your desktop folder with the following command:
- git clone https://github.com/Mike-Opanasiuk/CryptoService.git
- open cloned project with Visual Studio 2022 (.NET 7 required)

- run AuthService project (5010 ssl port)
- run OrderService project (5020 ssl port)
- run ApiGateway project (5030 ssl port) (uses as a gateway for OrderService microservice to easily provide one gateway to all services that could be created in the future)

