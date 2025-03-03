//import { MouseEvent } from "react";

import { useState } from "react";

interface ListGroupProps {
  items: string[];
  heading: string;
  onSelectItem: (item: string) => void;
}

function ListGroup({ items, heading, onSelectItem }: ListGroupProps) {
  //Hook
  const [selectedIndex, setSelectedIndex] = useState(-1);

  //const getMessage = () => {
  //  return items.length === 0 ? <p>There are no items in the list</p> : null;
  //};

  //{getMessage()}

  //Event handler
  //const handleClick = (event: MouseEvent) => console.log({ event });

  return (
    <>
      <h1>{heading}</h1>
      {items.length === 0 && <p>There are no items in the list</p>}
      <ul className="list-group">
        {items.map((item, index) => (
          <li
            className={`list-group-item ${
              index === selectedIndex ? "active" : ""
            }`}
            key={item}
            onClick={() => {
              setSelectedIndex(index);
              onSelectItem(item);
            }}
          >
            {item}
          </li>
        ))}
      </ul>
    </>
  );
}

export default ListGroup;
