(ns first-app.Zadanie1)

(defn Zad1
  [x]
  (- 
   (Math/pow (apply + (for [i (range x)] (inc i))) 2)
  (apply + (for [i (range x)] (Math/pow (inc i) 2)))))

(Zad1 10)

