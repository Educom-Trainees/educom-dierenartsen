import React from 'react'
import Button from './Button'

export default {
    title: 'Button',
    component: Button
}

export const Primary = () => <Button variant='primary'>Primary</Button>
export const Secondary = () => <Button variant='secondary'>Secondary</Button>
export const Sucess = () => <Button variant='succes'>Succes</Button>
export const Danger = () => <Button variant='danger'>Danger</Button>