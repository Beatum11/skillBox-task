import React from 'react';
import { useNavigate } from "react-router-dom";
import '../../css-files/css-blog/blog-item.css';

const BlogItem = ({date, img, title, content, clickHandler}) => {

  const navigate = useNavigate();
  const finalDate = new Date(date);
  const formattedDate = finalDate.toLocaleDateString();
  
  const teaserLimit = 150;
  // Create the teaser text
  let teaserText = content;
  if (content.length > teaserLimit) {
    // Cut off the text at the limit, and add ellipsis (...) at the end
    teaserText = `${content.substring(0, teaserLimit)}...`;
  }

  const openBlogPostHandler = () => {
    navigate("/blogPost", {
      state: {
        title: title,
        text: content,
        img: img,
        date: formattedDate
      },
    });
  };

  return (
    <div className='blogItem-container'>
        <p className='blogItem-date'>{formattedDate}</p>
        <img alt='Blog post cover' src={img}/>
        <h4 className='dark-skill-color'>{title}</h4>
        <p className='blogItem-description'>{teaserText}</p>
        <button onClick={openBlogPostHandler}>Read More</button>
    </div>
  )

}

export default BlogItem;