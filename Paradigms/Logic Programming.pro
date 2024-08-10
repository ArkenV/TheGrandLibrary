% Facts: Representing philosophers and their ideas
% Demonstrating declarative knowledge representation
philosopher(socrates, ancient_greek).
philosopher(plato, ancient_greek).
philosopher(aristotle, ancient_greek).
philosopher(descartes, enlightenment).
philosopher(kant, enlightenment).
philosopher(nietzsche, modern).
philosopher(sartre, modern).

% Philosophical ideas and their originators
% Demonstrating more complex fact representation
idea(socrates, 'Socratic method').
idea(plato, 'Theory of Forms').
idea(aristotle, 'Virtue ethics').
idea(descartes, 'Cogito ergo sum').
idea(kant, 'Categorical imperative').
idea(nietzsche, 'Ubermensch').
idea(sartre, 'Existentialism').

% Philosophical schools and their adherents
% Demonstrating grouping and classification
school(rationalism, [descartes, spinoza, leibniz]).
school(empiricism, [locke, berkeley, hume]).
school(existentialism, [kierkegaard, nietzsche, sartre, camus]).

% Influence relationships
% Demonstrating logical relationships
influenced(socrates, plato).
influenced(plato, aristotle).
influenced(aristotle, aquinas).
influenced(descartes, spinoza).
influenced(kant, hegel).
influenced(hegel, marx).
influenced(nietzsche, sartre).

% Rules: Defining complex relationships
% Demonstrating logical inference
philosophical_descendant(X, Y) :- influenced(X, Y).
philosophical_descendant(X, Y) :- 
    influenced(X, Z), 
    philosophical_descendant(Z, Y).

% Contemporaries: Philosophers from the same era
% Demonstrating equality and variable unification
contemporaries(X, Y) :-
    philosopher(X, Era),
    philosopher(Y, Era),
    X \= Y.

% Finding all ideas of a philosophical school
% Demonstrating list processing and backtracking
school_ideas(School, Ideas) :-
    school(School, Philosophers),
    findall(Idea, (member(P, Philosophers), idea(P, Idea)), Ideas).

% Counting philosophers in a school
% Demonstrating aggregation
school_size(School, Size) :-
    school(School, Philosophers),
    length(Philosophers, Size).

% Tracing philosophical lineage
% Demonstrating recursion and path finding
philosophical_lineage(X, Y, Lineage) :-
    philosophical_lineage(X, Y, [X], Lineage).

philosophical_lineage(X, X, Lineage, Lineage).
philosophical_lineage(X, Y, Visited, Lineage) :-
    influenced(X, Z),
    \+ member(Z, Visited),
    philosophical_lineage(Z, Y, [Z|Visited], Lineage).

% Queries (to be run in Prolog interpreter)
% ?- philosophical_descendant(socrates, X).  % Who are Socrates' philosophical descendants?
% ?- contemporaries(kant, X).  % Who were Kant's contemporaries?
% ?- school_ideas(existentialism, Ideas).  % What are the ideas associated with existentialism?
% ?- school_size(rationalism, Size).  % How many philosophers are associated with rationalism?
% ?- philosophical_lineage(socrates, sartre, Lineage).  % What's the philosophical lineage from Socrates to Sartre?