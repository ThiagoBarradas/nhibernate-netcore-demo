## NHibernate with NET Core 2.1 - Demo

Test this project with docker:


Running mysql
```
docker run --name mysql-server -p 3306:3306 -e MYSQL_DATABASE=nhibernate -e MYSQL_USER=myuser -e MYSQL_PASSWORD=mypass -e MYSQL_ROOT_PASSWORD=rootpass -d mysql:5.7.16
```

Build and running demo applicatiion
```
docker build -t nhibernatedemo .
docker run --name nhibernatedemo -it --link mysql-server nhibernatedemo
```


## Did you like it? Please, make a donate :)

if you liked this project, please make a contribution and help to keep this and other initiatives, send me some Satochis.

BTC Wallet: `1G535x1rYdMo9CNdTGK3eG6XJddBHdaqfX`

![1G535x1rYdMo9CNdTGK3eG6XJddBHdaqfX](https://i.imgur.com/mN7ueoE.png)
