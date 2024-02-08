import React from 'react';
import SocialFooter from './FooterSocials';
import { faFacebook, faTwitter, faInstagram } from '@fortawesome/free-brands-svg-icons';

export default {
  title: 'MOLECULES/SocialFooter',
  component: SocialFooter,
};

const socialIcons = [
  { icon: faFacebook, link: 'https://www.facebook.com/' },
  { icon: faTwitter, link: 'https://twitter.com/' },
  { icon: faInstagram, link: 'https://www.instagram.com/' },
  // Add more social icons as needed
];

const Template = (args) => <SocialFooter {...args} />;

export const Default = Template.bind({});
Default.args = {
  socialIcons: socialIcons,
};