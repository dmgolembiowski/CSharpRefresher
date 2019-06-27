#!/usr/bin/env python3
import antigravity
import turtle

class Self:
    pass

class Turtle(turtle.Turtle):
    def __init__(self, **kw):
        self = Self
        self.__dict__.update(kw)

    def fly(self):
        return antigravity.fly()

def main():
    gertrude = Turtle(name='Gertrude')
    gertrude.color = 'Green'
    gertrude.can_fly = True
    while gertrude.can_fly:
        sys.exit(
            gertrude.fly()
        )
