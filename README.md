# SRADCodingChallenge

I decided to go with the approach of returning Exceptions as a way of presenting back to the user if a method is out of bounds of acceptable functionality here.

I've also made an assumption that a matches score will not decrease, as I understand in football the score cannot be decreased.  

I also opted to got with a Collection of Match objects to manage the Matches as the simplest way to manage our in memory list of matches.  towards the end when implementing the ordering I clocked I needed a date Added field to ensure that the matches are presented as requested.

I've made an assumption that when updating matches teams and scores will be given in the correct order.

to ensure this I have not allowed a user to add the same tema should they be playing in any current match.  