import React from 'react';
import PropTypes from 'prop-types';
import Footer from '../../molecules/Footer/Footer';
import SocialFooter from '../../molecules/Footersocials/FooterSocials';


function CombinedFooter({ leftText, rightText, socialIcons }) {
  return (
    <div className="CombinedFooter">
      <SocialFooter socialIcons={socialIcons} />
      <Footer leftText={leftText} rightText={rightText}/>
    </div>
  );
}

CombinedFooter.propTypes = {
  leftText: PropTypes.arrayOf(PropTypes.string).isRequired,
  rightText: PropTypes.arrayOf(PropTypes.string).isRequired,
  socialIcons: PropTypes.arrayOf(
    PropTypes.shape({
      icon: PropTypes.object.isRequired,
      link: PropTypes.string.isRequired,
    })
  ).isRequired,
};

export default CombinedFooter;