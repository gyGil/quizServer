# Quiz Server
> It serves Quiz game service to clients through message queue.

### Used Technologies

C#, Message Queue, Microsoft Service, Visual Studio  

## Description

It provides the quiz for connected clients in local network through message queue. It is composed of 3 application 

* Service app
	It runs server in Microsoft service. Service grab the quiz from database and distributes to clients. It saves the score to database.

* Admin app
	It start quiz for clients. it grab score and information of client in realtime.

* Client app
	It take the quiz from server and send the answer to server. Client can see the result in realtime whether they get the answer or not.


## Screen Shot

## Installation

Windows:

```sh

```

## Usage example

## Development setup