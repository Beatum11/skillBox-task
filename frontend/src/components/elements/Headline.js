import React from 'react';
import '../../css-files/css-elements/headline.css';

const Headline = ({text}) => {

  return (
        <h1 className='dark-skill-color headline'>{text}</h1>
  );

}

export default Headline;