(ns first-app.Zadanie3)


;; Zad3a
(defn fibSteps
  [x]
  (def steps (atom 0))
  (fib x)
  @steps)



(defn fib
  [n]
  (swap! steps inc)
  (if (< n 2)
    n
    (+ (fib (- n 1)) (fib (- n 2)))))



;; Zad3b
(def fibResults (hash-map 1 1))

(defn Zad3b
  [n]
  (if (not (contains? fibResults n)) 
    (if (< n 2) 
      (def fibResults (merge-with + fibResults (hash-map n n)))
      (def fibResults (merge-with + fibResults (hash-map n (+ (fib (- n 1)) (fib (- n 2)))))))
    (get fibResults n)))
 


;; Zad3c
(defn Zad3c
  [x y]
  (def ve (vector 0 1))
  (loop [i x]
    (when (< i y)
      (def ve (vector (get ve 1) (apply +' ve))
      (recur (inc i))))
  (get ve 1)) 

(Zad3c 1 10000)
