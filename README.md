borde fungera på grund av att 0.0.0.0:5144 kör över alla network interfaces (10.x.x.x)
medan det vi gjorde innan var att vi körde den över din ip 10.71.x.x vilket låste den till det subnetet
derför kunde inte en dator som min 10.81.x.x komma åt den

10.81.x.x --❎--> 10.71.x.x
10.81.x.x --✔️--> 0.0.0.0

(om min hjärna fungerar rätt)
