(ns first-app.Zadanie2)

; a. Wzór na pierwiastek sześcienny - zaimplementować




; b. Przebieg procedury Herona uzależnić od Epsilon
; c. Przebieg procedury Herona uzależnić od N (ilości kroków)


 (defn fib [n] (if (< n 2) n (+ (fib (- n 1)) (fib (- n 2)))))

 

 (fib 10)