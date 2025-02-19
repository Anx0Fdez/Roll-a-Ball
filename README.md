# Roll A Ball
*Anxo Fernandez Rodriguez*

![Roll a Ball](images/img1.png)

## Scripts y funcionamiento del juego
### 1. PlayerController
* [Script do Xogador](Assets/Scripts/PlayerController.cs) 

**Descrición básica do Script:** Este código define un controlador para un xogador que pode moverse coas frechas do teclado, recoller obxectos, e detectar colisións. Emprega un Rigidbody para mover ao xogador fisicamente e detectar colisións con obxectos etiquetados como "PickUp" ou "Enemy". Un contador actualiza e mostra a cantidade de obxectos recollidos, activando unha mensaxe de vitoria ao alcanzar un límite. Se o xogador colisiona cun inimigo, destrúese o xogador e mostra unha mensaxe de derrota. O movemento está restrinxido ás teclas de frecha.

### 2. CameraController
* [Script da cámara en terceira persoa](Assets/Scripts/CameraController.cs)

**Descrición básica do Script:** Este código crea un controlador para que unha cámara siga a un xogador mantendo unha distancia fixa (offset). No método Start, calcúlase a distancia inicial entre a cámara e o xogador, e en LateUpdate actualízase a posición da cámara para que coincida coa do xogador máis o offset, asegurando un seguimento suave.

### 3. FirstPersonController
* [Script da cámara en primeira persoa](Assets/Scripts/FirstPersonController.cs)

**Descrición básica do Script:** Este código implementa un controlador de cámara en primeira persoa que se move e rota segundo as teclas de frecha presionadas. A dirección do movemento calcúlase coas teclas, e a cámara rota suavemente cara a esa dirección utilizando interpolación (Quaternion.Slerp). Ademais, a posición da cámara actualízase para avanzar na dirección calculada, creando un movemento e orientación coherentes.

### 4. CameraSwitcher
* [Script para cambiar de cámara](Assets/Scripts/CameraSwitcher.cs)

**Descrición básica do Script:** Este código implementa un sistema para alternar entre múltiples cámaras nunha escena. Un arranxo almacena as cámaras configuradas, e só unha está activa ao inicio. Ao presionar a tecla "C", desactívase a cámara actual e actívase a seguinte no arranxo, creando un ciclo circular entre elas. O método ActivateCamera asegura que só a cámara seleccionada estea habilitada en cada momento.

### 5. EnemyMovement
* [Script que controla a un inimigo](Assets/Scripts/EnemyMovement.cs)

**Descrición básica do Script:** Este código permite que un inimigo persiga ao xogador utilizando NavMeshAgent en Unity. Primeiro, obtén unha referencia ao xogador e ao compoñente NavMeshAgent. En cada fotograma (Update), o inimigo establece como destino a posición do xogador, o que fai que o siga automaticamente polo escenario, evitando obstáculos. O sistema funciona sempre que o escenario teña un NavMesh xerado e que o inimigo teña un compoñente NavMeshAgent configurado.

### 6. Proyectil
* [Script que controla os lanzamentos dos proxectís inimigos](Assets/Scripts/Proyectil.cs)

**Descrición básica do Script:** Este código controla o movemento e as colisións dun proxectil en Unity. En cada fotograma, o proxectil avanza en liña recta cunha velocidade determinada. Se colisiona cun obxecto que ten o tag "Player" ou "Walls", destrúese automaticamente. Isto permite que os proxectís desaparezan ao impactar ao xogador ou a unha parede, evitando que sigan na escena innecesariamente.

### 7. RampBoost
* [Script que controla o boost das rampas](Assets/Scripts/RampBoost.cs)

**Descrición básica do Script:** Este código proporciona un impulso ao xogador cando entra en contacto cunha rampa. Ao detectar que un obxecto co tag "Player" colisiona co trigger, obtén o seu Rigidbody e aplica unha forza na dirección combinada da normal da rampa e a dirección da rampa. O impulso aplícase con ForceMode.Impulse para que o efecto sexa inmediato. Este sistema permite que o xogador reciba un empuxe natural ao tocar a rampa, ideal para mecánicas de plataformas ou velocidade.

### 8. Torreta
* [Script do inimigo que lanza proxectís](Assets/Scripts/Torreta.cs)

**Descrición básica do Script:** Este código controla unha torreta que detecta ao xogador e dispara proxectís na súa dirección a intervalos regulares. En Start(), busca ao xogador usando o tag "Player". En Update(), verifica se o xogador existe e, se pasou o tempo necesario, dispara un proxectil. En Shoot(), calcúlase a dirección cara ao xogador e instánciase un proxectil cunha rotación que o faga apuntar correctamente. A torreta disparará automaticamente mentres o xogador estea en escena, asegurando que cada proxectil se dirixa cara á súa posición actual.

### 9. Rotator
* [Script que controla a rotación dos Pick ups](Assets/Scripts/Rotator.cs)

**Descrición básica do Script:** Este código fai que un obxecto rote constantemente nos tres eixes (X, Y, Z) en cada fotograma. En Update(), a función transform.Rotate() aplica unha rotación baseada no tempo (Time.deltaTime), o que asegura que a velocidade de rotación sexa constante e independente dos FPS. A rotación realízase cos valores (15, 30, 45), o que fai que o obxecto xire de maneira uniforme en todas as direccións. Este script é útil para crear efectos visuais como obxectos flotantes, power-ups xiratorios ou decoracións dinámicas na escena.

### 10. ReiniciarXogador
* [Script que fai reaparecer ao xogador ao inicio do nivel](Assets/Scripts/ReiniciarXogador.cs)

**Descrición básica do Script:** Este código detecta cando o xogador entra en contacto cun trigger e teletranspórtao a un punto de reinicio predefinido. puntoDeReinicio é un obxecto na escena que define a posición á que se enviará ao xogador. OnTriggerEnter(Collider other) detecta se o obxecto que entra no trigger ten o tag "Player". Se é o xogador, a súa posición actualízase á de puntoDeReinicio. Este sistema é útil para checkpoints, límites de caída ou zonas de reinicio en plataformas e xogos de aventura.
*