/* MULTICHOICE DATABASE INITIALIZATION */
CREATE DATABASE mcDatabase;
USE mcDatabase;

/* MULTICHOICE TABLE SETUP */
CREATE TABLE gameTable (gameID INT PRIMARY KEY AUTO_INCREMENT, userName VARCHAR(40), isRunning BOOL DEFAULT TRUE);
CREATE TABLE questionTable (questionID INT PRIMARY KEY AUTO_INCREMENT, question VARCHAR(255));

CREATE TABLE scoreTable (gameID INT, questionID INT, timeTaken INT, primary key(gameID, questionID), 
foreign key (gameID) references GameTable(gameID), foreign key (QuestionID) references QuestionTable(QuestionID));

CREATE TABLE answersTable (answerID INT PRIMARY KEY, answer1 VARCHAR(50), answer2 VARCHAR(50), answer3 VARCHAR(50), answer4 VARCHAR(50), correctAnswer INT);
CREATE TABLE leaderBoardTable (gameID INT PRIMARY KEY, totalScore INT);

/* SELECT STATEMENTS FOR ADMIN */

/* LIVE GAMEPLAY DISPLAY FOR ADMIN */
SELECT userName, gameTable.gameId, questionId, timeTaken FROM gameTable 
INNER JOIN scoreTable ON gameTable.gameId = scoreTable.gameId;

/* QUESTION & ANSWER TABLES FOR ADMIN */
SELECT * FROM questionTable INNER JOIN answersTable ON questionId = answerId
ORDER BY questionId DESC;

/* AVERAGE & PERCENTAGE (OFFICE AUTOMATION) FOR ADMIN */
SELECT questionTable.questionId AS 'QUESTION ID', question AS 'Question', AVG(timeTaken) 
AS 'Average Time Taken' FROM questionTable INNER JOIN scoreTable 
ON questionTable.questionId = scoreTable.questionId ORDER BY questionTable.questionId DESC;

/* QUESTION & ANSWER TABLE UPDATE */
UPDATE questionTable SET question = 'Listen to me very carefully!' WHERE questionId = 2;
UPDATE answersTable SET answer1 = 'I have something to say.', answer2 = 'Stop talking.',
									answer3 = 'Ill be back!', answer4 = 'Its not a tumor!',
									correctAnswer = 3 WHERE answerId = 2;

/* LEADER BOARD TABLE DISPLAY FOR BOTH USERS & ADMIN */
SELECT userName, totalScore FROM gameTable INNER JOIN leaderBoardTable
ON gameTable.gameId = leaderBoardTable.gameId ORDER BY totalScore DESC;

/* SELECT STATEMENTS FOR USERS */


/* TEST QUERIES FOR DEBUGGING (DISREGARD FOR PROGRAM) */
SHOW TABLES;
SELECT * FROM gameTable;
DROP TABLE scoreTable;
SELECT * FROM scoreTable;
SELECT * FROM leaderBoardTable;
SELECT * FROM questionTable;
SELECT * FROM answersTable;

INSERT INTO questionTable (question) VALUES ('Remember when I said I would kill you last?');
INSERT INTO questionTable (question) VALUES ('Who is your daddy and what does he do?');

INSERT INTO answersTable (answerId, answer1, answer2, answer3, answer4, correctAnswer)
VALUES (1, "I didn't mean it!", "I meant it!", "I lied!", "I told you the truth!", 3);

INSERT INTO answersTable (answerId, answer1, answer2, answer3, answer4, correctAnswer)
VALUES (2, "Not sure what my daddy does?", "I'm a cop you idiot!", "He's a cop", "My dad doesn't do shit!", 2);

INSERT INTO gameTable (userName) VALUES ('Arnold');
INSERT INTO gameTable (userName) VALUES ('Sylvester');

INSERT INTO scoreTable (gameId, questionId, timeTaken) VALUES ('1', '2', '5');
INSERT INTO scoreTable (gameId, questionId, timeTaken) VALUES ('2', '3', '7');

INSERT INTO leaderBoardTable (gameId, totalScore) VALUES (1, 40);
INSERT INTO leaderBoardTable (gameId, totalScore) VALUES (2, 18);

INSERT INTO scoreTable (gameId, questionId, timeTaken)
VALUES (3, 2, 5);

