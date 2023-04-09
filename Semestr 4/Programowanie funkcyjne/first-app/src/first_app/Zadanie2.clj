(ns first-app.Zadanie2)


(defn Zad2b
  [number epsilon]
  (def x0 (atom (double (/ number 3))))
  (def x1 (atom (double (/ (+ (* 2 @x0) (/ number (* @x0 @x0))) 3))))

  (while (> (Math/abs (double (- @x1 @x0))) epsilon)
    (do
      (println "x1 " @x1 "x0 " @x0)
      (reset! x0 @x1)
      (reset! x1 (/ (+ (* 2 @x0) (/ number (* @x0 @x0))) 3))))
  
  @x1)

(Zad2b 125 0.01)



(defn Zad2c
  [number steps]
  (def x0 (atom (double (/ number 3))))
  (def x1 (atom (double (/ (+ (* 2 @x0) (/ number (* @x0 @x0))) 3))))

  (dotimes [i steps]
    (reset! x0 @x1)
    (reset! x1 (/ (+ (* 2 @x0) (/ number (* @x0 @x0))) 3)))

  @x1)

(Zad2c 125 7)

