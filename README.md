borde fungera på grund av att 0.0.0.0:5144 kör över alla network interfaces (10.x.x.x)
medan det vi gjorde innan var att vi körde den över din ip 10.71.x.x vilket låste den till det subnetet
derför kunde inte en dator som min 10.81.x.x komma åt den

10.81.x.x --❎--> 10.71.x.x


10.81.x.x --✔️--> 0.0.0.0

(om min hjärna fungerar rätt)


Hello Iskas Ai Here just wanted to add this:

This should work better because the server now binds to 0.0.0.0:5144, which means ASP.NET listens on all IPv4 network interfaces on the server PC, instead of only one specific IP like 10.71.39.98:5144. Other computers must still connect to the server PC’s actual IP address, and it also requires that routing and firewall rules allow access to port 5144.
