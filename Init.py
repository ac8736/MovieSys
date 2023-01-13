import pymysql.cursors

def create_connection():
    return pymysql.connect(host='127.0.0.1',
                        user='root',
                        password='password',
                        db='movie_sys',
                        charset='utf8mb4',
                        cursorclass=pymysql.cursors.DictCursor)

conn = create_connection()
cursor = conn.cursor()
query = "CREATE TABLE movies(id CHAR(36) not null,`name` varchar(255) not null,director varchar(255) not null,release_date date not null,PRIMARY KEY (id))"
cursor.execute(query)
query = "CREATE TABLE `user`(id CHAR(36) not null,email varchar(255) not null,`username` varchar(255) not null,`password` varchar(255) not null,PRIMARY KEY (id, email))"
cursor.execute(query)
query = "CREATE TABLE movie_cast(movie_id char(36) not null,actor_name varchar(255) not null,`role` varchar(255) not null,PRIMARY KEY (movie_id, actor_name, `role`),FOREIGN KEY (movie_id) REFERENCES movie(id))"
cursor.execute(query)
query = "CREATE TABLE rating(movie_id CHAR(36) not null,user_id char(36) not null,rating int not null,comment varchar(255) not null,PRIMARY KEY (movie_id, email),FOREIGN KEY (movie_id) REFERENCES movie(id),FOREIGN KEY (user_id) REFERENCES `user`(id))"
cursor.execute(query)
query = "CREATE TABLE topic(movie_id CHAR(36) not null,topic varchar(255) not null,PRIMARY KEY (movie_id, topic),FOREIGN KEY (movie_id) REFERENCES Movie(id))"
cursor.execute(query)
query = "CREATE TABLE watched(movie_id CHAR(36) not null,user_id char(36) not null,PRIMARY KEY (movie_id, user_id),FOREIGN KEY (movie_id) REFERENCES movie(id),FOREIGN KEY (user_id) REFERENCES `user`(id))"
cursor.execute(query)

query = "INSERT INTO `user` VALUES('682671f8-00f1-4155-8416-8b4f3ff97126', 'test@test.com', 'test', '$2a$11$bGf1S0ImGJWRMdHwnTQL9uAbd0oMxvkYqcIQD20RLDv6pzOKZznSS')"
cursor.execute(query)
query = "INSERT INTO movie VALUES('9a2adc60-a772-4495-8290-d39e653a0228', 'Avatar', 'James Cameron', '2009-12-18')"
cursor.execute(query)
query = "INSERT INTO movie_cast VALUES('9a2adc60-a772-4495-8290-d39e653a0228', 'Sam Worthington', 'Jake Sully')"
cursor.execute(query)
query = "INSERT INTO rating VALUES('9a2adc60-a772-4495-8290-d39e653a0228', '682671f8-00f1-4155-8416-8b4f3ff97126', 5, 'Great movie')"
cursor.execute(query)
query = "INSERT INTO topic VALUES('9a2adc60-a772-4495-8290-d39e653a0228', 'Sci-Fi')"
cursor.execute(query)
query = "INSERT INTO watched VALUES('9a2adc60-a772-4495-8290-d39e653a0228', '682671f8-00f1-4155-8416-8b4f3ff97126')"
cursor.execute(query)

conn.commit()
cursor.close()
conn.close()