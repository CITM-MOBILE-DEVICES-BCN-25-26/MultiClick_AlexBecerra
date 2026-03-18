Long press threshold = 500 milisegundos  
Short click threshold = 300 milisegundos  
<br><br><br>
* El button inicialmente esta en idle.  
* Al presionar el button, el bool waitingLongPress cambia a true y hace un try-catch donde comprueba si el button se mantiene pulsado durante el threshold.  
* Si se cumple, printea el mensaje LongPress y se reseta el estado del button.
* Si se deja de pulsar el button antes, en la funcion OnPointerUp el bool vuelve a ser false.  
<br><br>
* Al dejar de pulsar el button, comprueba si estaba haciendo un longPress. En el caso de que si lo fuera, sale de la funcion para no contarlo como un click.  
* NumClicks++. Si numClicks == 1 hace un try-catch donde comprueba si se hace otro click durante el threshold. Si no hay interrupciones, printea ShortClick y se resetea el estado del button.  
* Si se interrumple pulsando otra vez, comprueba si es longPress o shortClick. Si es shortCick NumClicks pasa a ser 2, printea el mensaje DoubleClick y resetea el estado del button.  
<br><br>
Cada vez que se presiona o se deja de presionar el button, se cancela el cancelationToken y se crea uno nuevo.
