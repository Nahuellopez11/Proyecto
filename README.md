Proyecto Final "Batalla Pokemon"                                

UCU Programación 2 N1 Equipo 6

Integrantes del equipo: Nahuel López, Manuela Martony, Mathías Porley y Mathías Mallarini

IMPORTANTE LEER;

Aclaraciones hacia los profesores antes de corregir:
- Al principio del proyecto teniamos la ambición de crear 2 modos de batalla, batalla contra la máquina y batalla contra otro jugador. Pero por la complejidad de este en el Bot y en la consola nos quedamos con el modo planteado para la entrega, batalla de jugador contra jugador.
- Nos hubiese gustado cambiar nuestra forma de crear, seleccionar y agregar pokemones (Catalogo -> SeleccionPokeVisitor -> ElegirPokemon) a una forma más simple y efectiva, pero dado por varios motivos (tiempo, problemas, etc.) no pudimos lograrlo.
- No tenemos una clase test llamada "Historias de Usuario", los tests tienen comentarios en los cuales se indicia cuales de los tests hacen referencia o aluden a las historias de usuario.
- Puede ser que algun ataque falle (por precisión) y que los tests salgan "Failed", para solucionar esto corran los unit tests devuelta (al tiempo de escribir esto todos dan Success)
- Al iniciar el programa se debe ingresar en la consola 1 o 2 para seleccionar el modo del juego; si se ingresa 1 se inicia el bot y si se ingresa 2 comienza el juego en la consola.
- En cuanto al coverage de los tests, la siguiente imagén muestra lo que se deberia incluir (según el equipo) para este:

![image](https://github.com/user-attachments/assets/9bc5ce58-75ab-4fea-b42e-b6ca7d2a5ca4)

Clases como ElegirPokemon, SistemaCombate, CatalogoPokemon e InicializacionBatallaContraJugador contienen solamente métodos, los cuales se utilizan íntegramente en los tests (se crea, selecciona y agrega pokemones, se checkea a través de SistemaCombate que las peleas tengan y sigan la lógica planteada y las utilidades que se integran en InicializaciónBatallaContraJugador se testean aparte cada una de ellas) por lo tanto no los integramos en el coverage total.

El bot, interfaces y visitor no forman parte del coverage de los tests según lo hablado en clase.

La clase "Play.cs" del proyecto princial "Program" tampoco forma parte de los tests, contiene código dentro de un método estático "Main" para iniciar el juego en bot o consola.



INSTRUCCIONES PARA JUGAR CON EL BOT;
- Para comenzar el bot primero se debe runnear el proyecto e insertar "1" en la consola.
- Una vez hecho esto el bot se iniciara en el server de discord.
- Luego los dos jugadores que quieran jugar escribiran "!join" en el chat del server y se agregaran a la lista de espera para jugar (se puede ver la lista de jugadores en espera escribiendo "!WaitingList")
- Una vez que los dos forman parte de la lista de espera uno de los dos comenzara la batalla entre ellos escribiendo el comando "!battle Nombre de Discord de la otra persona en la lista de espera".
- Al hacer esto se le indicara al jugador1 (el que escribio !battle) de elegir 6 pokemones, luego aparecera una lista con todos los pokemones elegibles (ordenados por id), para que el jugador eliga sus pokemones tiene que introducir el comando "!seleccion" y 6 IDs de los pokemones separados por espacios (necesita introducir 6, si no introduce 6 o repite alguno de los IDs, no funciona el comando), un ejemplo de este comando sería "!seleccion 1 2 3 4 5 6". Una vez que el jugador1 eligió sus 6 pokemones el jugador2 tendra que elegir los suyos de misma forma.
- Luego se les mostrara a los jugadores sus equipos y empezara la batalla, siendo su primer ID de pokemón el pokemón elegido al comenzar. La persona con el primer movimiento o turno es random.
- Luego la persona con el turno puede elegir entre 3 opciones: La unica semi-funcional que pudimos hacer fue la opción 1, al escribir "atacar" se muestra la lista de los ataques del pokemon elegido; las demas opciones hubiesen sido: 2 cambiar pokemon y 3 utilizar item pero no las pudimos lograr agregar por varios motivos (ver comentarios)

COMENTARIOS;

Mathias Mallarini -> Me parecio interesante y divertida la idea del Pokemón de consola, el bot me parecio muy confuso y muy díficil de entender con cosas que no dimos en el curso, me daban errores de "DiscordSocketChannel" y agregar nuevos comandos me pedía instalar "Discord Package version 3.0.4" el cual no se queria instalar por alguna razón, y muchos errores más que tenía que buscar en ChatGPT y StackOverflow, que me llevaban a cosas que aun menos entendía. Lo mas frustrante es que realmente quería que el bot funcionase, no solo por la nota (la cual me parece bastante poca por lo que es), sino también porque me interesan los videojuegos y esta era como mi primera oportunidad de crear un "juego". Estuve varios días trabajando en él y realmente no entendí varias cosas de él, darle un foco mayor durante el curso hubiese estado bueno en mi opinión, y sí, podrias decir que fue mi culpa por no entender o no buscar suficiente información y también puede ser el caso, pero varios de los equipos ni se gastaron en el bot, lo cual pudo estar bueno y divertido de hacer si surgia la oportunidad de llegar a entender cómo funciona a través de las clases, al final del día mi opinión es que fue una pérdida de una gran oportunidad de hacer algo interesante y término siendo algo frustrante y confuso para mí.
