import PropTypes from 'prop-types'
import './_paragraph.style.scss';

const Paragraph = ({ content = '', size, ...props }) => {
  return (
    <p className={`paragraph-- ${size}`} {...props}>
      {content}
    </p>
  )
}

Paragraph.propTypes = {
  content: PropTypes.string,
  size: PropTypes.oneOf(['small', 'medium', 'large']),
}

export default Paragraph