import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Header from '../../molecules/Header/Header';
import Button from '../../atoms/buttons/Button';
import ParagraphMolecule from '../../molecules/ParagraphHome/ParagraphHome';
import CombinedFooter from '../../organisms/FooterDual/CombinedFooter';
import { faTiktok, faXTwitter, faInstagram, faYoutube } from '@fortawesome/free-brands-svg-icons';
import { faHome, faPaw, faUser, faCalendar, faEnvelope } from '@fortawesome/free-solid-svg-icons'
import contentImage from '../../../Images/dog-cat-friends.png';
import './_homepage.style.scss';
// import { faEnvelope, faCalendar,  } from '@fortawesome/free-regular-svg-icons';

const HomePage = () => {
  const [isMenuOpen, setMenuOpen] = useState(false);

  const headerData = {
    menuOptions: [
      { label: 'Home', icon: faHome },
      { label: 'About', icon: faPaw },
      { label: 'Contact', icon: faEnvelope },
      { label: 'Afspraak', icon: faCalendar },
      { label: 'Login', icon: faUser },
    ],
    onMenuToggle: () => setMenuOpen(!isMenuOpen),
  };

  const paragraphData = {
    content1: (
      <>
        Waar liefde en zorg samenkomen 
        <br />
        voor de gezondheid en vreugde 
        <br />
        van uw trouwe <span style={{ color: '#806F60' }}>Huisdier</span>.
      </>
    ),
    content2: (
      <>
        Bij HappyPaw begrijpen we dat uw huisdier een speciale plaats
        <br />
        inneemt in uw hart en gezin. Ons toegewijde team van ervaren 
        <br />
        dierenartsen staan klaar om de best mogelijke zorg te bieden 
        <br />
        voor uw trouwe metgezel.
      </>
    ),
    size1: 'large',
    size2: 'medium',
  };

  const footerData = {
    leftText: ['About HappyPaw', 'Contact us'],
    rightText: ['HappyPaw 2023 '],
    socialIcons: [
      { icon: faXTwitter, link: 'https://twitter.com/' },
      { icon: faInstagram, link: 'https://www.instagram.com/' },
      { icon: faYoutube, link: 'https://www.youtube.com/' },
      { icon: faTiktok, link: 'https://www.tiktok.com/' },

    ],
  };

  return (
    <div className="HomePage">
      <Header {...headerData} />
      <main>

        <div className='contentHome'>
          <div className="paragraph-container">
            <ParagraphMolecule {...paragraphData} />
            <Link to="/secondPage">
              <Button 
                label="Plan afspraak " 
                variant="primary"
                icon={faCalendar}
              />
            </Link>
          </div>

          <div className="image-container">
            <img src={contentImage} alt="Cat and Dog" />
          </div>

          <div className='ad-text'>
            <p>1000+ <br></br>Blije huisdieren</p>
          </div>
          
        </div>
          <div className='brown-background'> </div>
      </main>
      <CombinedFooter {...footerData} />
    </div>
  );
};


export default HomePage;