# Roll a Ball `Unity`
###### Anxo Fernández Rodríguez

---
![Roll a Ball](images/img1.png)

## Descrición
Este proxecto é un xogo de habilidade no que o xogador controla unha esfera que debe recoller obxectos nun escenario 3D. O obxectivo é recoller todos os obxectos posibles no menor tempo posible. O xogo conta cun contador de tempo e un contador de obxectos recollidos.

## Controis
- **W, A, S, D**: Mover a esfera.

## Obxectos
- **Cubos**: Suma 1 ao contador de obxectos recollidos.

## Escenario
O escenario é un plano con cubos distribuídos aleatoriamente. Ademais conta con obstáculos que o xogador debe evitar se non quere perder tempo.
- **Contador de obxectos recollidos**: Mostra o número de obxectos recollidos.
- **Mensaxe de vitoria**: Aparece cando se recollen todos os obxectos.

## Scripts

>[!IMPORTANT]
> - `Script` de movemento da esfera: [PlayerController.cs](Assets/Scripts/CameraController.cs)
> - `Script` de movemento da cámara: [CameraController.cs](Assets/Scripts/CameraController.cs)
> - `Script` para cambiar entre cámaras: [CameraSwitcher.cs](Assets/Scripts/CameraSwitcher.cs)
> - `Script` para a primeira persoa da cámara: [FirstPersonController.cs](Assets/Scripts/FirstPersonController.cs)

## Explicación dos `Scripts`

### PlayerController
- `Start()`: Inicializa `Rigidbody`, contador de obxectos e UI.
- `OnMove(InputValue movementValue)`: Detecta e converte a entrada de movemento.
- `FixedUpdate()`: Aplica forzas de movemento.
- `OnTriggerEnter(Collider other)`: Xestiona a recollida de obxectos.
- `SetCountText()`: Actualiza a UI.

### FirstPersonController
- `Update()`: Chama a `MoveAndRotateCamera()`.
- `MoveAndRotateCamera()`: Move e rota a cámara.

### CameraSwitcher
- `Start()`: Inicializa e establece a cámara activa.
- `SwitchCamera()`: Cambia a cámara activa.