cd /Users/stark/Documents/Projects/Choless/Choless.Data/MySQL
docker run --name choless-mysql-server -v $(pwd):/var/lib/mysql -e MYSQL_ROOT_PASSWORD=root -p 3306:3306 -d mysql