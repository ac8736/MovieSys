CREATE TABLE movie(
    id CHAR(36) not null,
    `name` varchar(255) not null,
    director varchar(255) not null,
    release_date date not null,
    PRIMARY KEY (id)
);

CREATE TABLE `user`(
    id CHAR(36) not null,
    email varchar(255) not null,
    `username` varchar(255) not null,
    `password` varchar(255) not null,
    PRIMARY KEY (id, email)
);

CREATE TABLE movie_cast(
    movie_id char(36) not null,
    actor_name varchar(255) not null,
    `role` varchar(255) not null,
    PRIMARY KEY (movie_id, actor_name, `role`),
    FOREIGN KEY (movie_id) REFERENCES movie(id)
);

CREATE TABLE rating(
    movie_id CHAR(36) not null,
    user_id char(36) not null,
    rating int not null,
    comment varchar(255) not null,
    PRIMARY KEY (movie_id, email),
    FOREIGN KEY (movie_id) REFERENCES movie(id),
    FOREIGN KEY (user_id) REFERENCES `user`(id)
);

CREATE TABLE topic(
    movie_id CHAR(36) not null,
    topic varchar(255) not null,
    PRIMARY KEY (movie_id, topic),
    FOREIGN KEY (movie_id) REFERENCES Movie(id)
);

CREATE TABLE watched(
    movie_id CHAR(36) not null,
    user_id char(36) not null,
    PRIMARY KEY (movie_id, user_id),
    FOREIGN KEY (movie_id) REFERENCES movie(id),
    FOREIGN KEY (user_id) REFERENCES `user`(id)
);