USE master
GO

IF DB_ID('afa') IS NOT NULL
BEGIN
ALTER DATABASE afa SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE afa;
END
CREATE DATABASE afa
GO

CREATE TABLE players(
	player_id int IDENTITY(1,1) NOT NULL,
	first_name nvarchar(60) NOT NULL,
	last_name nvarchar(60) NOT NULL,
	nickname varchar(100) NULL,
	CONSTRAINT [PK_players] PRIMARY KEY (player_id)

)

CREATE TABLE games(
	game_id int IDENTITY(100,1) NOT NULL,
	title varchar(100) NOT NULL,
	info varchar(600) NULL,
	CONSTRAINT [PK_games] PRIMARY KEY (game_id)
)

CREATE TABLE tournaments(
	tournament_id int IDENTITY(1,1),
	number int NOT NULL,
	game_id int NOT NULL,
	tournament_date SMALLDATETIME NOT NULL,
	winner_id int NULL,
	description varchar(1000) NULL,
	image varchar(200) NULL,
	image_of_winner varchar(200) NULL,

	CONSTRAINT[PK_tournament_id] PRIMARY KEY(tournament_id),
	CONSTRAINT[FK_game_id] FOREIGN KEY(game_id) REFERENCES games(game_id),
	CONSTRAINT[FK_winner_id] FOREIGN KEY(winner_id) REFERENCES players(player_id),

)

CREATE TABLE posts(
	heading varchar(200)NOT NULL,
	body varchar(1500) NULL,
	
)
GO