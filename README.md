# WorktestUnity_HernanPlager

## Level Design

Parámetros configurables desde Inspector de Unity:

- Caja Resorte -> Vertical Bounce Factor. Min: 0.5 (rebote reducido al mínimo) - Max: 1.5 (rebote amplificado al máximo) - 1: Mantiene mismo rebote

- Héroe -> Velocity. Min: 3 - Max: 9

- Lanzador -> Time Between Throws. Min: 1 - Max: 6 (segundos)

- Roca -> Velocity. Min:1 - Max:4
        -> Life Time. Min:1 - Max:4 (segundos)

- Coin -> Life Time. Min:3 - Max:7 (segundos)

- Game -> Quantity Of Stones For Coin. Min:1 - Max:5 (rocas)

- Timer -> TimeLevel. Min: 10 - Max: 120 (segundos)


## Programación

Cada x segundos, la clase Lanzador instancia una nueva roca. La clase Roca, a su vez, instancia un objeto (bezier) al cual asigna las posiciones de sus 3 wayPoints (puntos que la roca tendrá que recorrer en su próxima trayectoria). Dichas posiciones son asignadas de forma aleatoria, siempre que el último wayPoint coincida con el suelo (excepto el último rebote, que se dirige directo al target). Si la caja resorte se interpone en la trayectoria, se interrumpe la parábola y se reposiciona el primer wayPoint en la última posición de la roca al tocar la caja. De esta forma, el objeto bezier, junto con sus objetos hijos (wayPoints), se desplazan hacia la derecha de la pantalla, respetando la distancia entre ellos, a excepción de que la caja resorte tenga un factor de rebote vertical distinto a 1, lo cual afecta la altura del rebote. Los cuerpos rígidos sólo se utilizan en función de la detección de triggers, puesto que la física provista por Unity no está implementada. El método encargado de calcular las parábolas está basado en la fórmula de curva cuadrática de Bézier: https://es.wikipedia.org/wiki/Curva_de_B%C3%A9zier#Curvas_cuadr%C3%A1ticas_de_B%C3%A9zier        


## Arte

- Reconfigurado tamaño de Roca mediante Pixels Per Unit (estaba demasiado pequeña).

- Modificado Filter Mode a Point (no filter) en Moneda, Roca y Heroe (al ser pixel art, quedaba borroso con el filtrado).

- Modificado, a través de Sprite Editor, márgenes de sprites en Moneda y Roca (al tener márgenes demasiado amplios y distintos entre sí, quedaba desparejo el HUD Coins Count y Stones Count). 

- Modificado Draw Mode a Tiled en sprites de background, para que el patrón de la imagen se repita y quede más amplio que el viewport de la cámara.

- Modificado Wrap Mode a Repeat en Sky y Buildings, para poder hacer el efecto parallax (modificando el UV Rect de raw image).




