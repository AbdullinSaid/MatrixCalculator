Калькулятор матриц.
В калькуляторе поддерживается 8 функций.
1.Нахождение следа матрицы.
2.Транспортирование матрицы.
3.Сумма двух матриц.
4.Разность двух матриц.
5.Произведение двух матриц.
6.Умножение матрицы на число.
7.Нахождение определителя матрицы.
8.Решение СЛАУ методом Крамера.

Поддерживается ввод матриц через консоль или файл. Также есть возможность рандомизированной генерации.

Матрица задается в единственном формате:
n m
a11 . . . a1m
. . . . . . .
. . . . . . .
an1 . . . anm

где n и m - размеры матрицы(обязательно вводить их в одной строке, числа должны быть неотрицательными и не больше 1000).

Пример правильного ввода:
3 5
1 2 3 5 5
3 5 23 40 4
12 4 2 4 3

Для файлового данный формат матрицы должен находиться в файле типа .txt
в консоль нужно передать полный путь к этому файлу, например: C:\Users\username\RiderProjects\MatrixCalculator\MatrixCalculator\default.txt

Для рандомизированной генерации нужно вывести в консоль в одной строке:
n m left right

где n и m - размеры матрицы, left и right - границы рандомизации, то есть в матрице будут числа в диапозоне [left; right](left <= right)