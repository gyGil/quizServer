CREATE DATABASE mcDatabase;
USE mcDatabase;

CREATE TABLE gameTable (gameID INT PRIMARY KEY AUTO_INCREMENT, userName VARCHAR(40), isRunning BOOL DEFAULT TRUE);
CREATE TABLE questionTable (questionID INT PRIMARY KEY AUTO_INCREMENT, question VARCHAR(255));
CREATE TABLE scoreTable (gameID INT PRIMARY KEY AUTO_INCREMENT, questionID INT, userPoints INT);
CREATE TABLE answersTable (answerID INT PRIMARY KEY, answer1 VARCHAR(50), answer2 VARCHAR(50), answer3 VARCHAR(50), answer4 VARCHAR(50), correctAnswer INT);
CREATE TABLE leaderBoardTable (gameID INT PRIMARY KEY, totalScore INT);

SHOW TABLES;
SELECT * FROM answersTable;
