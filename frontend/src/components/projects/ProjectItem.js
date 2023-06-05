import React from 'react';
import '../../css-files/css-projects/project-item.css';

const ProjectItem = ({title ='Default title', imgUrl, clickHandler}) => {

  // Set the background image style
  const backgroundStyle = {
    backgroundImage: `url(${imgUrl})`,
    backgroundSize: 'cover'
  };

  return (
    <div style={backgroundStyle} className='projectItem-container'>
        <h4 onClick={clickHandler} className='dark-skill-color'>{title}</h4>
    </div>
  )
}

export default ProjectItem;