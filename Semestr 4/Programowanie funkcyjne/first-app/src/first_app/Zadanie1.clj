(ns first-app.Zadanie1)

(defn square [x]
  (* x x))

(defn squareSum [y]
  (apply + (for [i (range y)] (square (inc i)))))

(defn sequenceSum [z]
  (apply + (for [i (range z)] (inc i))))

(defn sumSquareDiffrence [n]
  (- (square (sequenceSum n)) (squareSum n)))

(sumSquareDiffrence 100)





