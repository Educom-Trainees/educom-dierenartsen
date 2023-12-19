import React from 'react'
import './Button.css'

function Button(props) {
    const { variant = 'primary', children, ...rest } = props
    return ( 
        <button classname={`button ${variant}`} {...rest}>
            {children}
        </button>
    )
}

export default Button