import PropTypes from 'prop-types'
import './_heading.style.scss'

const Heading = ({ level, text, className }) => {
    const Tag = `h${level}`;
  
    return <Tag 
            className={'Heading'}>
            {text}
           </Tag>;
  };

Heading.propTypes = {
    level: PropTypes.oneOf([1,2,3,4,5]).isRequired,
    text: PropTypes.string.isRequired,
    className: PropTypes.string,
}

export default Heading