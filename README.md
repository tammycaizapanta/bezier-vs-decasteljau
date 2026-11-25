# BezierLab – Bernstein vs. De Casteljau

Aplicación Windows Forms (.NET Framework 4.7.2) que evalúa curvas de Bézier con polinomios
de Bernstein y con el algoritmo de De Casteljau, las dibuja a la vez y mide tiempos y
diferencias numéricas.

Curso 202651_36867 · Segundo Parcial · Tammy Caizapanta, Laura Quiroz, Julio Sánchez, Bernardo Suárez.

## Ejecutar
Abrir `BezierLab.sln` en Visual Studio 2022 y pulsar F5. Para medir tiempos: modo **Release** y **Ctrl+F5**.

## Uso
- Clic izquierdo: agregar punto · arrastrar: mover · clic derecho: eliminar.
- Muestras y t se cambian en el panel derecho.
- "Medir curva actual" y "Prueba completa": 10 repeticiones con Stopwatch, sin incluir el dibujo.
  El resultado se copia del cuadro de texto a `datos/resultados.txt` del informe en Overleaf.

## Estructura
- `BezierLab/Logica/Vector2.cs` – punto 2D (base)
- `BezierLab/Logica/Bernstein.cs` – evaluación directa (Tammy)
- `BezierLab/Logica/DeCasteljau.cs` – algoritmo de De Casteljau (Laura)
- `BezierLab/Logica/Medicion.cs` – Stopwatch y diferencias (Julio)
- `BezierLab/BezierLab.cs` – ventana y dibujo (Bernardo)
