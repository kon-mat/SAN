(ns first-app.Zadanie3)


(defn fib
  [n]
  (swap! steps inc)
  (if (< n 2)
    n
    (+ (fib (- n 1)) (fib (- n 2)))))


;; Zad3a
(defn fibSteps 
  [x]
  (def steps (atom 0))
  (fib x)
  @steps)


;; Zad3b
(def fibResults (hash-map 1 1))

(defn Zad3b
  [n]
  (if (not (contains? fibResults n)) 
    (if (< n 2) 
      (def fibResults (merge-with + fibResults (hash-map n n)))
      (def fibResults (merge-with + fibResults (hash-map n (+ (fib (- n 1)) (fib (- n 2)))))))
    (get fibResults n)))
  



(println fibResults)

(def fibResults {}) 

(Zad3b 11)

