# PizzaMaster

This program is associated to a C# quest.

## Compiling

Use Visual Studio on Windows/Mac or Mono on Linux to compile the program.

## Usage

Once you are in the directory of the executable

```
$ ./PizzaMaster
```

## Access

The URL to access it is https://localhost:12345/PizzaMaster

Be sure that this port don't already have a service running on.

## What to do ?

This program only provides a way to order pizzas. Basically it only increments a counter in memory when receiving the proper request.

Unless you are feeding it with a POST request it will return a 405 Bad Request.

### Request format

To play with the program you must send data as **form/raw**. A paramater named ***nbPizzas*** will do the thing.

```
$ curl -d "nbPizzas=2" http://localhost:12345/PizzaMaster
You have 2 pizzas ordered
```

If you need to decrement it just set ***nbPizzas*** to a negative number.

```
$ curl -d "nbPizzas=2" http://localhost:12345/PizzaMaster
You have 2 pizzas ordered
$ curl -d "nbPizzas=-2" http://localhost:12345/PizzaMaster
You have 0 pizzas ordered
```


## Ownership

Propriety of Wild Code School, written by PREVOST Corentin.
